using System.Text.RegularExpressions;
using AssociationRegistry.EventCatalog;
using AssociationRegistry.EventCatalog.Analyzers;
using Scriban;

var input = new Parameters
{
    SourcePath = "/src",
    EventCatalogPath = "/catalog"
};

Console.WriteLine("Analyzing...");
var eventTemplate =
    Template.Parse(File.ReadAllText("templates/index.md"));
var serviceTemplate =
    Template.Parse(File.ReadAllText("templates/service.md"));

var allSources = string.Empty;

foreach (var filePath in Directory.EnumerateFiles(input.SourcePath,
             "*.cs", SearchOption.AllDirectories))
    allSources += File.ReadAllText(filePath);

var codeAnalyzer = new CodeAnalyzer(allSources);
var handlersPerEvents = codeAnalyzer.AnalyzeCode();

var domainFolder = Path.Join(input.EventCatalogPath, "domains");
Directory.EnumerateDirectories(domainFolder).ToList()
    .ForEach(x => Directory.Delete(x, true));

WriteEvents(input, handlersPerEvents, eventTemplate);
WriteHandlers(input, handlersPerEvents, serviceTemplate);

return 0;


void WriteHandlers(Parameters input,
    Dictionary<TypeInfo, List<TypeInfo>> handlersPerEvents,
    Template serviceTemplate)
{
    var servicesFolder =
        Path.Join(input.EventCatalogPath, "services");
    Directory.EnumerateDirectories(servicesFolder).ToList()
        .ForEach(x => Directory.Delete(x, true));

    foreach (var handler in handlersPerEvents.SelectMany(x => x.Value)
                 .Distinct())
    {
        var serviceRender = serviceTemplate.Render(
            new
            {
                Name = handler.Name, handler.Description
            });

        var handlerFolder = Path.Join(servicesFolder, handler.Name);
        Directory.CreateDirectory(handlerFolder);
        File.WriteAllTextAsync(Path.Join(handlerFolder, "index.md"),
            serviceRender);
    }
}

void WriteEvents(Parameters input,
    Dictionary<TypeInfo, List<TypeInfo>> handlersPerEvents,
    Template eventTemplate)
{
    var eventsFolder = Path.Join(input.EventCatalogPath, "events");
    Directory.EnumerateDirectories(eventsFolder).ToList()
        .ForEach(x => Directory.Delete(x, true));

    foreach (var handlersPerEvent in handlersPerEvents)
    {
        var eventRender = eventTemplate.Render(
            new
            {
                Name = handlersPerEvent.Key.Name, handlersPerEvent.Key.Description,
                Consumers = handlersPerEvent.Value.Select(x => x.Name)
            });

        Console.WriteLine($"Rendered {eventRender}");
        var eventFolder =
            Path.Join(eventsFolder, handlersPerEvent.Key.Name);
        Directory.CreateDirectory(eventFolder);
        Console.WriteLine("Writing to " + eventFolder);
        File.WriteAllTextAsync(Path.Join(eventFolder, "index.md"),
            eventRender);
    }
}

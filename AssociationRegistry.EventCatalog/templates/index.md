---
name: {{ name }}
version: 0.0.1
summary: |
  {{ summary }}
consumers:
{{ for consumer in consumers }}    - {{ consumer }}
{{ end }}
producers:
    - Beheer API
---

{{description}}
<Mermaid />
<Schema />

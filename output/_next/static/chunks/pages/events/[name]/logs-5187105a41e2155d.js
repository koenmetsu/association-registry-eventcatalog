(self.webpackChunk_N_E=self.webpackChunk_N_E||[]).push([[2276],{24418:function(e,s,n){(window.__NEXT_P=window.__NEXT_P||[]).push(["/events/[name]/logs",function(){return n(52332)}])},52217:function(e,s,n){"use strict";var a=n(24246),l=(n(27378),n(78915)),r=n(79894),t=n.n(r);s.Z=function(e){var s=e.pages,n=e.homePath,r=void 0===n?"/events":n;return(0,a.jsx)("nav",{className:"flex","aria-label":"Breadcrumb",children:(0,a.jsxs)("ol",{className:"flex items-center space-x-4",children:[(0,a.jsx)("li",{children:(0,a.jsx)(t(),{href:r,children:(0,a.jsxs)("a",{className:"text-gray-400 hover:text-gray-500",children:[(0,a.jsx)(l.Z,{className:"flex-shrink-0 h-5 w-5","aria-hidden":"true"}),(0,a.jsx)("span",{className:"sr-only",children:"Home"})]})})}),s.map((function(e){return(0,a.jsx)("li",{children:(0,a.jsxs)("div",{className:"flex items-center",children:[(0,a.jsx)("svg",{className:"flex-shrink-0 h-5 w-5 text-gray-300",xmlns:"http://www.w3.org/2000/svg",fill:"currentColor",viewBox:"0 0 20 20","aria-hidden":"true",children:(0,a.jsx)("path",{d:"M5.555 17.776l8-16 .894.448-8 16-.894-.448z"})}),(0,a.jsx)(t(),{href:e.href,children:(0,a.jsx)("a",{className:"ml-4 text-sm font-medium text-gray-500 hover:text-gray-700","aria-current":e.current?"page":void 0,children:e.name})})]})},e.name)}))]})})}},52332:function(e,s,n){"use strict";n.r(s),n.d(s,{__N_SSG:function(){return m}});var a=n(85034),l=n(24246),r=n(17532),t=n(27378),i=n(79894),c=n.n(i),d=n(26340),x=(n(90973),n(17782)),o=n(52217);function h(){for(var e=arguments.length,s=new Array(e),n=0;n<e;n++)s[n]=arguments[n];return s.filter(Boolean).join(" ")}var m=!0;s.default=function(e){var s=e.changes,n=e.event,i=e.breadCrumbs,m=n.version,u=n.name,f=function(e){var s=e===m;return n.domain?s?"/domains/".concat(n.domain,"/events/").concat(u):"/domains/".concat(n.domain,"/events/").concat(u,"/v/").concat(e):s?"/events/".concat(u):"/events/".concat(u,"/v/").concat(e)};return(0,t.useEffect)((function(){var e={drawFileList:!1,matching:"lines",highlight:!0,fileListToggle:!1,outputFormat:"side-by-side"};s.forEach((function(s,n){if(s.value){var a=document.getElementById("code-diff-".concat(n)),l=new d.ae(a,s.value,e);l.draw(),l.highlightCode()}}))}),[s]),(0,l.jsx)("div",{className:"flex relative min-h-screen",children:(0,l.jsx)("div",{className:" flex flex-col w-0 flex-1 ",children:(0,l.jsx)("main",{className:"flex-1 ",children:(0,l.jsx)("div",{className:"py-8 xl:py-10",children:(0,l.jsx)("div",{className:"max-w-5xl mx-auto px-4 sm:px-6 lg:px-8 xl:max-w-7xl xl:grid xl:grid-cols-4",children:(0,l.jsxs)("div",{className:"xl:col-span-4 flex-col justify-between flex ",children:[(0,l.jsx)("div",{className:"mb-5 border-b border-gray-100 pb-4",children:(0,l.jsx)(o.Z,{pages:i})}),(0,l.jsxs)("div",{children:[(0,l.jsx)("div",{className:"border-b pb-4 flex justify-between mb-4",children:(0,l.jsx)("div",{className:"space-y-2 w-full",children:(0,l.jsx)("h1",{className:"text-3xl font-bold text-gray-900 relative",children:u})})}),0===s.length&&(0,l.jsx)("div",{className:"text-gray-400 text-xl",children:"No versions for Event found."}),(0,l.jsx)("div",{className:"flow-root mb-20",children:(0,l.jsx)("ul",{className:"",children:s.map((function(e,n){return(0,l.jsx)("li",{className:"",children:(0,l.jsxs)("div",{className:"relative pb-8",children:[n!==s.length-1?(0,l.jsx)("span",{className:"absolute top-4 left-4 -ml-px h-full w-0.5 bg-gray-100","aria-hidden":"true"}):null,(0,l.jsxs)("div",{className:"relative flex space-x-3",children:[(0,l.jsx)("div",{children:(0,l.jsx)("span",{className:h("h-8 text-white text-xs w-8 rounded-full flex items-center justify-center ring-8 ring-white bg-blue-500"),children:(0,l.jsx)(x.Z,{className:"h-4 w-4"})})}),(0,l.jsxs)("div",{children:[(0,l.jsxs)("div",{children:[(0,l.jsxs)("p",{className:"font-bold text-gray-800 text-xl",children:["Schema version update",e.versions.map((function(e,s){return(0,l.jsx)(c(),{href:f(e),children:(0,l.jsxs)("a",{className:"font-medium",children:[0===s&&" from",(0,l.jsxs)("span",{className:"text-blue-500 underline px-1",children:[e,e===m?"(latest)":""]}),0===s&&"to"]})},e)}))]}),e.changelog.source&&(0,l.jsxs)(l.Fragment,{children:[(0,l.jsx)("h2",{className:"text-xl text-blue-500 font-bold mt-4 border-b border-gray-100 pb-2",children:"Changelog"}),(0,l.jsx)("div",{className:"prose max-w-none mt-2",children:(0,l.jsx)(r.R,(0,a.Z)({},e.changelog.source))})]}),!e.changelog.source&&(0,l.jsx)("h2",{className:"text-base text-gray-300 font-bold mt-4",children:"No changelog file found."})]}),(0,l.jsx)("div",{className:"text-right text-sm text-gray-500 py-4",children:(0,l.jsx)("div",{id:"code-diff-".concat(n)})})]})]})]})},n)}))})})]})]})})})})})})}}},function(e){e.O(0,[4371,9774,2888,179],(function(){return s=24418,e(e.s=s);var s}));var s=e.O();_N_E=s}]);
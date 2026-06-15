# Prompts para Notebook LM — Azure DevOps

---

## Prompt 1: Buscar fuentes

Pegar en Google/Bing/YouTube para recolectar materiales:

```
Azure DevOps tutorial for beginners 2025 2026 Azure Pipelines Boards Repos
Azure DevOps CI/CD pipeline .NET Core React complete example
Azure Boards Scrum Sprint management tutorial
Azure Pipelines YAML build and release .NET
Azure Repos branch policy pull request review
Azure DevOps vs GitHub Actions comparison
Azure DevOps best practices student project
```

Recomendados:
- https://www.youtube.com/playlist?list=PLi9Rnu3J3VCJpBdnFUJE0oZNf5Vw5vKkU (Azure DevOps for Beginners)
- https://learn.microsoft.com/en-us/azure/devops/ (documentación oficial)
- Canales: Microsoft DevOps, IAmTimCorey, Nick Chapsas

---

## Prompt 2: Para Notebook LM

Una vez tengas las fuentes subidas (links, PDFs, transcripts de YouTube), pega esto:

---

### 🎯 Propósito
Generar un material explicativo sobre Azure DevOps orientado a un estudiante de ingeniería informática que debe usarlo como requisito en un proyecto universitario. El proyecto usa ASP.NET Core + React/Vite + SQL Server, equipo de 5 personas, Scrum con 4 Sprints.

### 📋 Formato deseado
Generame estos 3 recursos a partir de las fuentes:

**1. Guía Rápida (Briefing Doc)**
- ¿Qué es Azure DevOps? Explicación simple
- Sus 4 servicios principales: Boards, Repos, Pipelines, Test Plans
- Cómo se relacionan entre sí
- Términos clave: Work Item, PR (Pull Request), Pipeline, Agent, Artifact

**2. Plan de Implementación Paso a Paso (Timeline)**
Día 1: Crear organización y proyecto en Azure DevOps
Día 2: Configurar Boards con Epics → Features → User Stories → Tasks
Día 3: Configurar Repos + Branch Policy (main, develop, feature/*)
Día 4: Pipeline CI básico (build + test automático al hacer PR)
Día 5: Pipeline CD a Azure App Service
Día 6-7: Integrar todo + Wiki del proyecto

**3. Ejemplos Concretos (FAQ / Study Guide)**
- "¿Cómo creo un Sprint en Azure Boards?"
- "¿Qué es un YAML pipeline y cómo se escribe uno para .NET?"
- "¿Cómo hago code review con Pull Requests?"
- "¿Cómo despliego automáticamente a Azure?"
- "¿Cómo gestiono tareas para 5 personas?"

### 📥 Fuentes incluidas
[Listar acá los links/documentos que subiste]

### 🎤 Extra: Audio Overview
Generá un Audio Overview (discusión tipo podcast, ~10-15 min) donde un instructor le explica Azure DevOps a un estudiante universitario que lo necesita para su proyecto. El tono debe ser práctico, con ejemplos concretos del flujo de trabajo diario, no teórico.

---

## Prompt 3: Para generar video (alternativa)

Si querés un video explicativo con pantallazos, usá este prompt para que Notebook LM te genere el **guión**:

```
Generame un guión de video de 10 minutos explicando Azure DevOps para un proyecto universitario.

Estructura:
1. Intro (30s): Qué es Azure DevOps y por qué lo usamos
2. Boards (2min): Crear proyecto, configurar Sprints, asignar tareas a 5 personas
3. Repos (2min): Crear repo, branches, políticas de PR
4. Pipelines (3min): YAML pipeline para .NET + React, build + test automático
5. Demo rápida (2min): Flujo completo — tarea → código → PR → build → deploy
6. Cierre (30s): Buenas prácticas

Cada sección debe indicar qué se muestra en pantalla (screen recording) y qué se dice (narración).

Tono: Práctico, directo, como un compañero explicándote.
```

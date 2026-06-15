# Prompt para Notebook LM — Azure DevOps

## Instrucciones

1. Abrí https://notebooklm.google.com
2. Creá un nuevo notebook
3. En "Add Sources" agregá **todos** los links de abajo (podés pegar las URLs)
4. Una vez cargados, pegá el prompt de abajo en el chat

---

## Fuentes para subir

### YouTube (agregar como URLs)

```
https://www.youtube.com/watch?v=Gd3mpakzqeA
https://www.youtube.com/watch?v=4BibQ69MD8c
https://www.youtube.com/watch?v=rXwUSCDH59Y
https://www.youtube.com/watch?v=xAB_6hCX7Sk
https://www.youtube.com/watch?v=--7g9w0gB9o
```

### Microsoft Learn (agregar como URLs)

```
https://learn.microsoft.com/en-us/shows/devops-lab/azure-devops-zero-to-hero-tutorial
https://learn.microsoft.com/en-us/azure/devops/boards/sprints/scrum-overview?view=azure-devops
https://learn.microsoft.com/en-us/devops/plan/what-is-scrum
https://learn.microsoft.com/en-us/azure/devops/pipelines/architectures/devops-pipelines-baseline-architecture?view=azure-devops
```

### Artículos

```
https://medium.com/@sonalisood0/azure-devops-boards-a-guide-for-developers-2025-1d6f157eb80d
https://medium.com/@syed.sas74/how-i-built-an-end-to-end-agile-project-with-azure-devops-boards-repos-and-sprints-8bb5d8426394
https://www.prioxis.com/blog/Azure-DevOps-Pipeline
https://github.com/nnellans/ado-pipelines-guide
```

---

## Prompt (pegá esto en Notebook LM)

Actuá como un instructor de Azure DevOps para un estudiante universitario de Ingeniería Informática. El estudiante ya sabe .NET (ASP.NET Core), React, SQL Server, y necesita usar Azure DevOps como requisito en un proyecto universitario con equipo de 5 personas, metodología Scrum, 4 Sprints de 2 semanas.

### Tarea

Generá los siguientes materiales a partir de las fuentes cargadas:

**1. Audio Overview (obligatorio)**
Generá un Audio Overview (discusión tipo podcast, ~20 minutos) con DOS participantes:
- **Instructor experto:** explica Azure DevOps con claridad, con ejemplos concretos
- **Estudiante:** hace preguntas prácticas, pide aclaraciones, relaciona con su proyecto

Temas que debe cubrir el audio en orden:
1. ¿Qué es Azure DevOps? (visión general, por qué existe, qué problema resuelve)
2. Azure Boards (crear proyecto, configurar Sprints, épicas → features → user stories → tareas, asignar a 5 personas)
3. Azure Repos (Git, branch strategy: main/develop/feature, políticas de PR, code review)
4. Azure Pipelines (CI/CD con YAML, build automático al hacer PR, deploy a Azure)
5. Flujo completo del día a día (task → code → PR → build → test → deploy)
6. Mejores prácticas para un proyecto universitario
7. Errores comunes y cómo evitarlos

Tono: Práctico, directo, como un compañero más avanzado explicándote. Nada teórico, todo aplicable.

**2. Briefing Doc**
Un documento de 1 página que contenga:
- Definición simple de Azure DevOps
- Los 4 servicios clave (Boards, Repos, Pipelines, Test Plans) y para qué sirve cada uno
- Glosario mínimo: Work Item, Sprint, Pull Request, Pipeline, Artifact, Agent
- Diagrama conceptual de cómo fluye el trabajo (task → code → PR → CI → CD → deploy)

**3. FAQ (preguntas frecuentes para estudiantes)**
- "¿Cómo empiezo? ¿Creo organización o proyecto primero?"
- "¿Qué proceso elijo: Agile, Scrum o Basic?"
- "¿Cómo reparto tareas entre 5 personas?"
- "¿Qué es un YAML pipeline y cómo lo escribo para mi proyecto .NET?"
- "¿Cómo hago que mi pipeline compile y pruebe automáticamente?"
- "¿Qué hago si mi pipeline falla?"
- "¿Cómo despliego a Azure automáticamente?"
- "¿Cómo conecto Azure DevOps con GitHub?"

**4. Timeline (paso a paso para configurar todo)**
Día 1: Crear organización y proyecto
Día 2: Configurar Boards (Sprints, Work Items, asignación)
Día 3: Subir código a Repos + branch policies
Día 4: Pipeline CI básico (build + test)
Día 5: Pipeline CD (deploy automático)
Día 6: Wiki + documentación
Día 7: Pull request review + demo final

---

## Respuesta esperada de Notebook LM

Notebook LM te va a generar (todo descargable):

1. **Video Overview** ⬅ MP4 en formato Explainer o Cinematic
2. **Audio Overview** ⬅ podcast MP3
3. **Briefing Doc** ⬅ resumen imprimible
4. **FAQ** ⬅ respuestas concretas
5. **Timeline** ⬅ checklists

---

## Cómo generar el Video Overview

En Studio, al lado de "Audio Overview" vas a ver **"Video Overview"**. Hacé clic y customizá:

| Campo | Valor |
|-------|-------|
| **Formato** | Explainer (o Brief si querés algo más corto) |
| **Idioma** | Español (Latinoamérica) |
| **Estilo visual** | Classic o Whiteboard |
| **Steering Prompt** | Enfocate en Azure Boards, Repos y Pipelines desde cero. Mostrá el flujo completo: crear proyecto → configurar Sprint → asignar tareas → code → PR → CI → deploy. Ignorá conceptos avanzados como release gates o approvals. |

Notebook LM tarda ~30 minutos en generar el video. Podés descargar el MP4 cuando termine.

---

## TIPS

- Si querés **Cinematic Video Overview** (más producido, estilo documental animado) seleccioná ese formato — requiere ser 18+
- Si generás el video y querés cambiarlo, podés editar el steering prompt y regenerar (no desde cero, se apoya en las fuentes ya cargadas)
- Combiná Video Overview + Audio Overview: el video te da la vista general, el podcast profundiza

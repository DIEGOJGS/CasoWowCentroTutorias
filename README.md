# 🚀 Caso Wow: Sistema de Control de Atenciones (UPN)

Este proyecto es una solución al "Caso Wow" del curso de Estructura de Datos de la Universidad Privada del Norte (UPN).

Es una aplicación de consola desarrollada en C# y .NET que simula un sistema de gestión de turnos para el Centro de Tutorías Académicas.

## 1. Problema Identificado

El centro usaba un sistema manual (hojas de cálculo) que causaba 3 problemas principales:
* **Desorden:** Alumnos atendidos fuera de turno.
* **Confusión:** Dificultad para saber quiénes estaban en espera.
* **Pérdida de Datos:** No existía un historial consolidado al final del día.

## 2. Estrategia y Estructura Elegida (Justificación)

La competencia del curso pedía usar estructuras de datos lineales. La estrategia elegida fue:

* **Dos Colas (Queues):** `Queue<Estudiante> Cola_Prioritaria` y `Queue<Estudiante> Cola_Regular`.
    * **Justificación:** Se eligieron colas por su naturaleza **FIFO (First-In, First-Out)**, lo que garantiza el orden de llegada justo. Usar dos colas permite gestionar el requisito de "prioridad" de forma eficiente: el sistema siempre atiende la cola prioritaria primero.

* **Una Lista (List):** `List<Estudiante> Lista_Historial`.
    * **Justificación:** Se eligió una lista para funcionar como un historial consolidado. Cada vez que un estudiante es atendido (sale de una cola), se agrega al final de esta lista, resolviendo el problema de "pérdida de datos".

## 3. Solución Propuesta (Implementación)

El proyecto está implementado en C# con 3 clases principales:

* `Estudiante.cs`: El "Modelo" que define las propiedades de un estudiante.
* `GestionTutorias.cs`: El "Controlador" que contiene la lógica, las 2 colas y la lista, con métodos como `RegistrarEstudiante()` y `AtenderSiguienteEstudiante()`.
* `Program.cs`: La "Vista" que muestra el menú interactivo al usuario en la consola.

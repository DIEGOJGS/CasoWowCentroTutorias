# 🚀 Caso Wow: Sistema de Control de Atenciones (UPN)

Este proyecto es una solución al "Caso Wow" del curso de Estructura de Datos. Lo que comenzó como un diseño lógico en consola ha sido implementado como una **aplicación de escritorio de Windows Forms** completa, desarrollada en C# y .NET.

El sistema gestiona los turnos del Centro de Tutorías Académicas, incluyendo una interfaz gráfica de usuario y una **base de datos SQLite** para persistencia de datos (historial y colas pendientes).

## 1. Problema Identificado

El centro usaba un sistema manual (hojas de cálculo) que causaba 3 problemas principales:
* **Desorden:** Alumnos atendidos fuera de turno.
* **Confusión:** Dificultad para saber quiénes estaban en espera.
* **Pérdida de Datos:** No existía un historial consolidado al final del día.

## 2. Estrategia Lógica (Base del Proyecto)

La competencia del curso pedía usar estructuras de datos lineales. La estrategia elegida fue:

* **Dos Colas (Queues):** `Queue<Estudiante> Cola_Prioritaria` y `Queue<Estudiante> Cola_Regular`.
    * **Justificación:** Se eligieron colas por su naturaleza **FIFO (First-In, First-Out)**, lo que garantiza el orden de llegada justo. Usar dos colas permite gestionar el requisito de "prioridad" de forma eficiente.

* **Una Lista (List):** `List<Estudiante> Lista_Historial`.
    * **Justificación:** Se usó una lista para funcionar como el historial consolidado en memoria durante la sesión.

## 3. Solución Implementada (Versión Extendida)

El proyecto inicial de consola fue extendido para crear una aplicación profesional completa, yendo más allá de los requisitos iniciales.

### Estructura del Repositorio

La solución de Visual Studio está dividida en tres proyectos:

1.  **`CasoWowCentroTutorias` (Biblioteca de Clases - La Lógica):**
    * `Estudiante.cs`: El "Modelo" que define al estudiante.
    * `GestionTutorias.cs`: El "Controlador" que maneja las colas y la lógica de atención.
    * `TutoriasDbContext.cs`: El "Puente" de Entity Framework Core que se conecta a la base de datos SQLite.

2.  **`CasoWow.AppVisual` (Aplicación de Windows Forms - La Vista):**
    * `MainForm.cs`: La interfaz gráfica de usuario (GUI) que permite registrar estudiantes, ver las colas en tiempo real y consultar el historial.

3.  **`CasoWowInstalador` (Setup Project):**
    * Un proyecto de instalador que empaqueta la aplicación en un archivo `.msi` y `setup.exe` para una distribución profesional.

### Tecnologías Clave

* **Windows Forms:** Para la interfaz gráfica de usuario.
* **Entity Framework Core (EF Core) con SQLite:** Para la persistencia de datos. La base de datos (`tutorias.db`) se crea automáticamente en la carpeta **"Mis Documentos"** del usuario para garantizar los permisos de escritura y que el historial sobreviva al cierre de la app.

## 4. Cómo Usar la Aplicación

### Método 1: Ejecutar la Aplicación Publicada (Recomendado)

1.  Descargar el archivo `.rar` o `.zip` de la entrega del proyecto.
2.  Descomprimir y abrir la carpeta `CasoWow` (que contiene la versión "publicada").
3.  Ejecutar el archivo `CasoWow.AppVisual.exe`.
4.  La aplicación se iniciará y se conectará/creará la base de datos `tutorias.db` en "Mis Documentos".

### Método 2: Ejecutar desde el Código Fuente (Para Desarrolladores)

1.  Clonar o descargar el ZIP de este repositorio.
2.  Abrir el archivo `CasoWowCentroTutorias.sln` con Visual Studio 2022.
3.  (Opcional) Instalar la extensión "Microsoft Visual Studio Installer Projects" si se desea compilar el proyecto `CasoWowInstalador`.
4.  Asegurarse de que `CasoWow.AppVisual` sea el "Proyecto de inicio" (clic derecho -> "Establecer como proyecto de inicio").
5.  Presionar F5 o el botón "Iniciar" (▶️).

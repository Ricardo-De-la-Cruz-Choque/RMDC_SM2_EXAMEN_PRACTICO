#  OFA – Organizar Fácil y Ágil
**Aplicación móvil de lista de compras inteligente**

---

##  Información general del proyecto

| Campo | Detalle |
|-------|----------|
| **Curso:** | Soluciones Móviles II |
| **Unidad:** | Examen Práctico – Unidad II |
| **Nombre del alumno:** | Ricardo Miguel De la Cruz Choque |
| **Periodo académico:** | Del 1 de septiembre al 1 de diciembre de 2025 |
| **Repositorio GitHub:** | [https://github.com/Ricardo-De-la-Cruz-Choque/SM2_EXAMEN_PRACTICO](https://github.com/Ricardo-De-la-Cruz-Choque/SM2_EXAMEN_PRACTICO) |
| **Nombre del proyecto:** | **OFA – Organizar Fácil y Ágil** |
| **Tecnología base:** | .NET MAUI (C#), SQLite, MVVM |
| **Tipo de aplicación:** | Aplicación móvil multiplataforma (Android / Windows) |

---

##  Descripción general

**OFA (Organizar Fácil y Ágil)** es una aplicación móvil desarrollada en **.NET MAUI** que permite al usuario **crear, organizar y gestionar listas de compras** de manera rápida y sencilla.  
Su objetivo principal es ayudar a las personas a planificar sus compras semanales, optimizando tiempo y evitando olvidos.

El proyecto fue desarrollado como parte del curso **Soluciones Móviles II**, aplicando buenas prácticas de desarrollo móvil, el patrón arquitectónico **MVVM** y persistencia local con **SQLite**.

---

##  Historia de Usuario

> **Título:** Gestionar mi lista de compras  
>
> **Como** usuario de la aplicación,  
> **quiero** registrar, visualizar y marcar los productos que debo comprar,  
> **para** tener una lista organizada que me permita realizar mis compras de forma rápida y sin olvidar ningún producto.

---

##  Criterios de aceptación

1. El usuario puede **agregar un nuevo producto** con su nombre y cantidad.  
2. El usuario puede **ver la lista completa** de productos pendientes o comprados.  
3. El usuario puede **marcar un producto como “comprado”**.  
4. El usuario puede **eliminar productos** de la lista.  
5. La aplicación debe **mantener la información guardada** incluso si se cierra (uso de SQLite).  
6. Debe existir un **campo de búsqueda** para filtrar productos por nombre o categoría.  
7. La aplicación debe **funcionar correctamente en modo local** desde Visual Studio.

---

## ⚙️ Funcionalidades implementadas

| Funcionalidad | Descripción |
|----------------|-------------|
|  **Agregar producto** | Permite registrar un nuevo producto indicando su nombre y cantidad. |
|  **Marcar como comprado** | Cambia el estado de un producto a “comprado” mediante un checkbox. |
|  **Eliminar producto** | Deslizando hacia la izquierda (Swipe) o con un botón, se elimina el producto de la lista. |
|  **Buscar/Filtrar productos** | Permite buscar por nombre o categoría en tiempo real. |
|  **Persistencia local (SQLite)** | Todos los datos se almacenan en una base `shopping.db3` interna. |
|  **Refrescar lista** | Botón que actualiza manualmente la lista desde la base de datos. |
|  **Interfaz adaptable (MAUI)** | Compatible con Android y Windows, con una interfaz limpia y funcional. |

---

## Arquitectura del proyecto

El proyecto sigue el patrón **MVVM (Model–View–ViewModel)** con la siguiente estructura:

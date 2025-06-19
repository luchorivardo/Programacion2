

document.addEventListener("DOMContentLoaded", function () {
    fetchAnimales();
});

function fetchAnimales() {
    fetch("https://localhost:7178/api/animal") // cambiá el puerto si tu API usa otro
        .then(response => {
            if (!response.ok) {
                throw new Error("Error al obtener animales");
            }
            return response.json();
        })
        .then(animales => {
            const tbody = document.querySelector("table tbody");
            tbody.innerHTML = ""; // limpiamos el contenido

            animales.forEach(animal => {
                const tr = document.createElement("tr");

                tr.innerHTML = `
                    <td>${animal.id}</td>
                    <td>${animal.nombre}</td>
                    <td>${animal.raza}</td>
                    <td>${animal.edad}</td>
                    <td>${animal.sexo}</td>
                    <td>${animal.tipoNombre || "N/A"}</td>
                    <td>${animal.duenoNombre || "N/A"}</td>
                    <td>
                        <a href="crearAnimal.html">Crear</a>
                        <a href="modificarAnimal.html?id=${animal.id}">Modificar</a>
                        <a href="#" onclick="eliminarAnimal(${animal.id})">Eliminar</a>
                    </td>
                `;

                tbody.appendChild(tr);
            });
        })
        .catch(error => {
            console.error("Error al cargar animales:", error);
        });
}

function eliminarAnimal(id) {
    if (!confirm("¿Estás seguro de eliminar este animal?")) return;

    fetch(`https://localhost:7178/api/animal/${id}`, {
        method: 'DELETE'
    })
    .then(response => {
        if (response.ok) {
            alert("Animal eliminado");
            fetchAnimales(); // recargar la tabla
        } else {
            alert("Error al eliminar");
        }
    })
    .catch(error => {
        console.error("Error al eliminar animal:", error);
    });
}
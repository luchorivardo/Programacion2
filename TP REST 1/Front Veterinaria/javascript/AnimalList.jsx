import React, { useEffect, useState } from "react";
import axios from "axios";

function AnimalList() {
  const [animales, setAnimales] = useState([]);

  // 🚀 useEffect se ejecuta una sola vez cuando el componente se monta
  useEffect(() => {
    obtenerAnimales();
  }, []);

  // ✅ Función que hace GET a la API y guarda los datos en el estado
  const obtenerAnimales = async () => {
    try {
      const response = await axios.get("https://localhost:7178/api/animal");
      setAnimales(response.data); // guarda la respuesta (array de animales) en el estado
    } catch (error) {
      console.error("Error al obtener animales:", error);
    }
  };

  // 🗑️ Función para eliminar un animal (DELETE)
  const eliminarAnimal = async (id) => {
    const confirmar = window.confirm("¿Estás seguro de eliminar este animal?");
    if (!confirmar) return;

    try {
      await axios.delete(`https://localhost:7178/api/animal/${id}`);
      alert("Animal eliminado correctamente");
      // actualiza la lista quitando el animal eliminado
      setAnimales(animales.filter((a) => a.id !== id));
    } catch (error) {
      alert("Error al eliminar el animal");
      console.error(error);
    }
  };

  return (
    <div className="container mt-4">
      <h2>Lista de Animales</h2>

      <table className="table table-striped">
        <thead>
          <tr>
            <th>ID</th>
            <th>Nombre</th>
            <th>Raza</th>
            <th>Edad</th>
            <th>Sexo</th>
            <th>Tipo</th>
            <th>Dueño</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {animales.map((animal) => (
            <tr key={animal.id}>
              <td>{animal.id}</td>
              <td>{animal.nombre}</td>
              <td>{animal.raza}</td>
              <td>{animal.edad}</td>
              <td>{animal.sexo}</td>
              <td>{animal.tipoNombre || "N/A"}</td>
              <td>{animal.duenoNombre || "N/A"}</td>
              <td>
                <a href={`modificarAnimal.html?id=${animal.id}`}>Modificar</a>{" "}
                <button
                  className="btn btn-sm btn-danger"
                  onClick={() => eliminarAnimal(animal.id)}
                >
                  Eliminar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default AnimalList;

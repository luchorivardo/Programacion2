/*
function alertaBtGuardar(){
    alert( "Se registro exitosamente")
}

function limpiarCampos(){
    document.getElementById("textUsuario").value = "";
    document.getElementById("textApellido").value = "";
}
*/

function alertaBtGuardar() {
    const usuario = document.getElementById("textUsuario").value.trim();
    const apellido = document.getElementById("textApellido").value.trim();
    const sexo = document.getElementById("sexo").value;
    const fecha = document.getElementById("fechaNacimiento").value;
    const ciudad = document.getElementById("ciudad").value;

    const mensajeError = document.getElementById("mensajeError");
    let errores = [];

    if (usuario === "") errores.push("El campo Usuario es obligatorio.");
    if (apellido === "") errores.push("El campo Apellido es obligatorio.");
    if (sexo === "") errores.push("Debe seleccionar un sexo.");
    if (fecha === "") errores.push("Debe seleccionar una fecha de nacimiento.");
    if (ciudad === "") errores.push("Debe seleccionar una ciudad.");
    if (usuario.length > 10) errores.push("El campo Usuario no debe tener mas de 10 caracteres.");
    if (apellido == Number(apellido)) errores.push("El campo Apellido no debe tener numeros.");

    if (errores.length > 0) {
        mensajeError.innerHTML = errores.join("<br>");
        mensajeError.style.display = "block";
    } else {
        mensajeError.style.display = "none";
        alert(mostrarEdad());
        alert("Se registró exitosamente");
        
    }
}

function limpiarCampos() {
    document.getElementById("textUsuario").value = "";
    document.getElementById("textApellido").value = "";
    document.getElementById("sexo").value = "";
    document.getElementById("fechaNacimiento").value = "";
    document.getElementById("ciudad").value = "";
    document.getElementById("mensajeError").style.display = "none";
}

function mostrarEdad(){
    const fecha = document.getElementById("fechaNacimiento").value;

    let aux = fecha
    aux = String(aux)
    aux = substring(0,3) 
    let edad = Number(aux) - 2025
    
    return edad;

}

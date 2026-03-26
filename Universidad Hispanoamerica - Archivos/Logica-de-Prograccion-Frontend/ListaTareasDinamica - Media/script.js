class Item{
    constructor(nombre, prioridad){
        this.nombre = nombre;
        this.prioridad = prioridad;
    }
}

// Esto es para mantener los datos que se van arenderizar en memoria
const listaTareas = JSON.parse(localStorage.getItem('misTareas')) || [];
const contenedor = document.getElementById('container');

const agregarItem = () => {
    const nombreItem = document.getElementById('nombre');
    const prioridadItem = document.getElementById('prioridad');

    if(nombreItem.value !== "" && prioridadItem.value !== ""){
        let item = new Item(nombreItem.value, prioridadItem.value)
        listaTareas.push(item);

        // Aqui se guardan los cambios en memoria
        localStorage.setItem('misTareas', JSON.stringify(listaTareas));

        nombreItem.value = "";
        prioridadItem.value = "";
        renderizarLista();
    } else {
        alert("Debes llenar el formulario");
    }
};

const eliminarItem = (indice) => {
    listaTareas.splice(indice, 1);

    // Aqui se guardan los cambios en memoria
    localStorage.setItem('misTareas', JSON.stringify(listaTareas));

    renderizarLista();
};

const renderizarLista = () => {
    console.log("Renderizando.....", listaTareas);

    contenedor.innerHTML = "";

    if(listaTareas.length === 0){
        contenedor.innerHTML= "<p>No hay tareas pendientes!</p>";
        return;
    }

    listaTareas.forEach((tarea, indice) => {
        contenedor.innerHTML += `
            <div class="item">
                <p><strong>${tarea.nombre}</strong> - Prioridad ${tarea.prioridad}</p>
                <button class="btn-cambios" onclick="eliminarItem(${indice})">
                    <i class="fa-solid fa-trash btn-trash-icon"></i>
                </button>
            </div>
        `
    });
};

renderizarLista();
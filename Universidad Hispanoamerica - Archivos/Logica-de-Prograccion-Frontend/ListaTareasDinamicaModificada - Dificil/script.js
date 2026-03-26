class Item{
    constructor(nombre, prioridad){
        this.id = Date.now();
        this.nombre = nombre;
        this.prioridad = prioridad;
        this.completada = false;
    }
}

// Esto es para mantener los datos que se van arenderizar en memoria
const listaTareas = JSON.parse(localStorage.getItem('misTareas')) || [];
const contenedor = document.getElementById('container');

const agregarItem = () => {
    const nombreItem = document.getElementById('nombre');
    const prioridadItem = document.getElementById('prioridad');

    if(nombreItem.value !== "" && prioridadItem.value !== ""){
        let item = new Item(nombreItem.value, prioridadItem.value, false)
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
        const claseEstado = tarea.completada ? 'item-activo' : 'item-inactivo';
        const checked = tarea.completada ? 'checked' : '';
        const textoCompletado = tarea.completada ? '- Completada' : '';

        contenedor.innerHTML += `
            <div class="item ${claseEstado}">
                <input type="checkbox" ${checked} onclick="estaActiva(${tarea.id})" id="interruptor-${tarea.id}" class="interruptor">
                    <label for="interruptor-${tarea.id}" class="switch">
                    </label>
                <p><strong>${tarea.nombre}</strong> - Prioridad: ${tarea.prioridad} <strong class="is-complete">${textoCompletado}</strong></p>
                <button class="btn-cambios" onclick="eliminarItem(${indice})">
                    <i class="fa-solid fa-trash btn-trash-icon"></i>
                </button>
            </div>
        `
    });
};

const estaActiva = (id) => {
    const tarea = listaTareas.find(t => t.id === id);

    if(tarea){
        tarea.completada = !tarea.completada;

        // Guardar cambios
        localStorage.setItem('misTareas', JSON.stringify(listaTareas));
        
        const elementoItem = document.getElementById(`interruptor-${tarea.id}`).closest('.item');
        const textoArea = elementoItem.querySelector('p');

        if(tarea.completada){
            elementoItem.classList.replace('item-inactivo', 'item-activo');

            elementoItem.querySelector('.is-complete').innerText = '- Completada'; 
        } else {
            elementoItem.classList.replace('item-activo', 'item-inactivo');

            elementoItem.querySelector('.is-complete').innerText = ''; 
        }
    }
}


renderizarLista();
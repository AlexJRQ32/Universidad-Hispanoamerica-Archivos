import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'

function App() {
  const [tarea, setTarea] = useState("");
  const [lista, setLista] = useState([]);

  const agregarItem = (e) => {
    e.preventDefault();

    if(tarea.trim() === "") return;
    
    setLista([...lista, tarea]);
    setTarea("");
  }

  const eliminarItem = (indice) => {
    const nuevaLista = lista.filter((_, i) => i !== indice);
    setLista(nuevaLista);
  }

  return (
    <>
      <section className="form-header">
        <h1>Lista de Tareas Dinamica</h1>
      </section>
      <section className="form-body">
        <form onSubmit={agregarItem}>
          <input 
          type="text" 
          placeholder="Nombre de la Tarea"
          value={tarea}
          onChange={(e) => setTarea(e.target.value)} 
          />
          <button className="btn-cambios"  id="add-item" type="submit">
          <i className="fa-solid fa-plus"></i>
          </button>
        </form>
      </section>
      <section className="list-items">
        <div className="container"> 
          {lista.length === 0 && <p>¡No hay tareas pendientes!</p>}
          {lista.map((item, indice) => (
            <div class="item" key={indice}>
              <p><strong>{item}</strong></p>
              <button className="btn-cambios" onClick={() => eliminarItem(indice)}>
                <i className="fa-solid fa-trash btn-trash-icon"></i>
              </button>
            </div>
          ))}
        </div>
      </section>
    </>
  )
}

export default App

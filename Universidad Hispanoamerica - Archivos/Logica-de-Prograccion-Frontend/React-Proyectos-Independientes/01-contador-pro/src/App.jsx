import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'

function App() {
  const [contador, setContador] = useState(0);

  const incrementar = () => setContador(contador + 1);

  const desincrementar = () => {
    if(contador > 0){
      setContador(contador-1);
    } else {
      alert("No se puede desincrementar cuando el valor es 0")
    }
  }

  const resetear = () => setContador(0);

  return (
    <>
      <div className='counter'>
        <p>Contador: {contador}</p>
      </div>
      <div className="buttons">
        <button className="btn-accion" onClick={incrementar}>Sumar</button>
        <button className="btn-accion" onClick={desincrementar}>Restar</button>
        <button className="btn-accion" onClick={resetear}>Resetear</button>
      </div>
    </>
  )
}

export default App

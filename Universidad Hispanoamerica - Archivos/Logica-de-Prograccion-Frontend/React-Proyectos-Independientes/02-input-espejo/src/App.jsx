import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'

function App() {
  const [texto, setTexto] = useState("");



  return (
    <section className='input-espejo'>
      <input type="text" placeholder='Escribe algo aqui' 
      onChange={(e)=> setTexto(e.target.value)}
      />
      <p>Lo que escribiste es: <strong>{texto}</strong></p>
    </section>
  )
}

export default App

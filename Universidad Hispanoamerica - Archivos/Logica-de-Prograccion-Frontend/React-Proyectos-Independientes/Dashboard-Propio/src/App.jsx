import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'
import Navbar from './components/Navbar'
import NavbarLeft from './components/Navbar-left'


function App() {


  return (
    <div className='container'>
      <Navbar />

      <main>
        <NavbarLeft />
        <section className="container-main">
          <h1>Welcome to my dashboard</h1>
        <p></p>
        </section>
      </main>
    </div>
  )
}

export default App

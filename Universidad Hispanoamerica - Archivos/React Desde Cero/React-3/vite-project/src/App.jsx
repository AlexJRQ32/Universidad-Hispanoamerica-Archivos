import { useState } from "react"
import { Square } from "./components/Square"
import { TURNS, checkEndGame, checkWinner } from "./logic/Logic"
import { Board } from "./components/Board"
import { WinnerModal } from "./components/WinnerModal"

function App() {
  const [board, setBoard] = useState(() => {
    const savedBoard = localStorage.getItem('board')
    return savedBoard ? JSON.parse(savedBoard) : Array(9).fill(null)
  })

  const [turn, setTurn] = useState(() => {
    const savedTurn = localStorage.getItem('turn')
    return savedTurn ? JSON.parse(savedTurn) : TURNS.X
  })

  const [winner, setWinner] = useState(null)

  const resetGame = () => {
    setBoard(Array(9).fill(null))
    setTurn(TURNS.X)
    setWinner(null)
    localStorage.removeItem('board')
    localStorage.removeItem('turn')
  }

  const updateBoard = (index) => {
    if (board[index] || winner) return

    const newBoard = [...board]
    newBoard[index] = turn
    setBoard(newBoard)

    localStorage.setItem('board', JSON.stringify(newBoard))

    const newTurn = turn === TURNS.X ? TURNS.O : TURNS.X
    setTurn(newTurn)

    localStorage.setItem('turn', JSON.stringify(newTurn))

    const newWinner = checkWinner(newBoard)
    if (newWinner) {
      setWinner(newWinner)
    } else if (checkEndGame(newBoard)) {
      setWinner(false)
    }
  }

  return (
    <main className='board'>
      <h1>Tic tac toe</h1>
      <button onClick={resetGame}>Empezar de nuevo</button>
      <section className="game">
        <Board board={board} updateBoard={updateBoard} />
      </section>
      <section className="turn">
        <Square isSelected={turn === TURNS.X}>{TURNS.X}</Square>
        <Square isSelected={turn === TURNS.O}>{TURNS.O}</Square>
      </section>
      <WinnerModal winner={winner} resetGame={resetGame} />
    </main>
  )
}

export default App

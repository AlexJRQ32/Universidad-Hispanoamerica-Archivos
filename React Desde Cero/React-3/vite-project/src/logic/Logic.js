// No longer importing state from Constants.js



export const TURNS = {
    X : 'x',
    O : 'o'
}

export const WINNER_COMBOS = [
    [0,1,2], [3,4,5], [6,7,8],
    [0,3,6], [1,4,7], [2,5,8],
    [0,4,8], [2,4,6]
]

export const checkWinner = (boardToCheck) => {
    for(const combo of WINNER_COMBOS) {
        const [a,b,c] = combo
        if(boardToCheck[a] &&
            boardToCheck[a] === boardToCheck[b] &&
            boardToCheck[a] === boardToCheck[c]
        ){
            return boardToCheck[a]
        }
    }
    return null
}

export const checkEndGame = (newBoard) => {
    return newBoard.every((square) => square !== null)
}

// updateBoard and resetGame will be handled in App.jsx to properly manage state re-renders
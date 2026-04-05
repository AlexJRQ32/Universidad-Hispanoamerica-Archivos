import { Square } from "./Square"



export const Board = ({board, updateBoard}) => {
    return (
        board.map((_, index) => {
            return(
                <Square 
                    key={index}
                    isSelected={board[index] !== null}
                    index={index}
                    updateBoard={updateBoard}
                >
                    {board[index]}
                </Square>
            )
        })
    )
}
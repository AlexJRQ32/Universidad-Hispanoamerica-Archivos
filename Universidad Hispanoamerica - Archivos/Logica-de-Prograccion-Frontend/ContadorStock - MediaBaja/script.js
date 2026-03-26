let count = 0;


const aumentar = () => {
    if(count < 10){
        count++;
        actualizarValor()
    }else{
        alert("¡Límite de stock alcanzado!")
    }
}

const disminuir = () => {
    if(count > 0){
        count--;
        actualizarValor()
    }
}

const actualizarValor = () => {
    const numeroElemento = document.getElementById('numero');
    numeroElemento.innerText = count;

    if(count === 10){
        numeroElemento.style.color = '#ff4d4d';
    } else {
        numeroElemento.style.color = 'white';
    }
}
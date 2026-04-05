const contenedor = document.querySelector('.calc');
const escritura = contenedor.querySelector('.render-numbers span');


const clearCalc = () => escritura.innerHTML = "";

contenedor.addEventListener('click', (e) => {
    
    const btn = e.target.closest('.btn-tecla');

    if(!btn || btn.classList.contains('btn-clear')) {
        clearCalc();
        return;
    }

    const valor = btn.dataset.valor;
    

    if(valor === '='){
        try{
            let resultado = eval(escritura.innerHTML);
            escritura.innerHTML = Number(resultado.toFixed(2));
            setTimeout(clearCalc, 4000);
        }
        catch{
            escritura.innerHTML = "Error";
            setTimeout(clearCalc, 1500);
        }
    } else {
        if(escritura.innerHTML === "Error" || escritura.innerHTML === '0'){
            escritura.innerHTML = valor;
        } else {
            escritura.innerHTML += valor;
        }
    }
        
});


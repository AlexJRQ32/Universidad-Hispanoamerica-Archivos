var isFalse = false;

function changeTheme(){
    const miBody = document.querySelector('body')
    
    if(isFalse){
        miBody.style.backgroundColor = 'white';
        miBody.style.color = '#212121';
        isFalse = false
    } else{
        miBody.style.backgroundColor = '#212121';
        miBody.style.color = 'white';
        isFalse = true
    }
}


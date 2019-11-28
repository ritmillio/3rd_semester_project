const username = document.getElementById('name');
const password = document.getElementById('password');
const form = document.getElementById('');
const errorElement = document.getElementById('');

form.addEventListener('submit' , (e) =>{
    let messages = []
    let userName = "test";
    let passWord = "password";
    if(name.value === '' || name.value == null){
        message.push('Name is required')
    }
    if (password.value.length  <= 6) {
        messages.push('Password must be longer than 6 characters');
    }
    if (password.value.length >= 20) {
        messages.push('Password must be less than 20 characters');
    }
    if(messages.length > 0){
        e.preventDefault();
        errorElement.innerHTML = messages.join(', ')
    }
    if(username.value.match(userName) && password.value.match(passWord)){
        return true;
    }
})

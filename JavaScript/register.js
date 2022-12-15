document.getElementById("registerBtn")
.addEventListener('click', () => {

    fetch("http://localhost:5117/api/account/signUp", {
        method: "POST",
        headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify({
            email: document.getElementById("typeEmail").value,
            password: document.getElementById("typePassword").value,
            username: document.getElementById("typeUsername").value,
        })
    }).then(res => {
            
        if(res.ok) {
          
           alert("User successfully registered")
       
        } else{
       
            res.text().then(text => alert(text))
        }
      })
})

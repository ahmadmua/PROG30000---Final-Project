

document.addEventListener("DOMContentLoaded", (event) => {
    fetch("http://localhost:5117/api/media/watchlater", {
        method: "GET",
        headers: {
            "content-type": "application/json"
        },

    }).then(res => {

        if (res.ok) {



            res.json().then(text => {

                console.log(text)
                for (let i = 0; i < text.length; i++) {
                    const li = document.createElement("li")
                    li.innerHTML = text[i].toWatch


                    let ul = document.getElementById("myUL")
                    ul.appendChild(li)


                }
            })

        } else {

            alert("Error")
        }
    })
})




const addTaskButton = document.getElementById("addTaskButton");
const placeHolder = document.getElementById("placeholderForTasks");

addTaskButton.addEventListener("click", function (event) {
    event.preventDefault();
    let container = document.createElement("div");
    container.setAttribute("class", "inputForTask")
  
    let nextinput = document.createElement("input");
    nextinput.setAttribute("name", "task");
    nextinput.setAttribute("placeholder", "Task: ");
    
    placeHolder.append(container);
    container.appendChild(nextinput);

});

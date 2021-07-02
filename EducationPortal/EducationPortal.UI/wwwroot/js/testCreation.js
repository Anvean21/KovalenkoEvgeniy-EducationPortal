// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function AddQuestion() {

    var questionsCount = document.getElementById("questions").childElementCount;

    var button = document.getElementById("questionButton");
    button.hidden = true;

    var answerButton = document.createElement("button");
    answerButton.setAttribute("type", "button");
    answerButton.setAttribute("onclick", "AddAnswer()");
    answerButton.setAttribute("class", "btn btn-primary");
    answerButton.setAttribute("id", "AnswerButton");
    answerButton.innerHTML = 'Add New Answer';

    var div = document.createElement("div");
    div.className = "form-group row container-fluid justify-content-xl-between";


    var label1 = document.createElement("label");
    label1.innerText = "Question name:"
    label1.className = "col-md-4 col-form-label text-md-right";
    label1.setAttribute("asp-for", "Name");

    var input_div1 = document.createElement("div");
    input_div1.className = "col-md-6";

    var inner_div1 = document.createElement("div");
    inner_div1.className = "col-md-6";

    var input1 = document.createElement("input");
    input1.type = "text";
    input1.setAttribute("asp-for", "Name");
    input1.name = "Questions[" + questionsCount + "].Name";





    var extra = document.createElement("div");
    extra.className = "col-md-6";

    input_div1.appendChild(input1);


    inner_div1.appendChild(label1);
    inner_div1.appendChild(input1);



    div.appendChild(inner_div1);

    div.appendChild(answerButton);

    document.getElementById("questions").appendChild(div);
}
function AddAnswer() {
    var answersCount = document.getElementById("answers").childElementCount;
    var questionsCount = document.getElementById("questions").childElementCount - 1;

    var div = document.createElement("div");
    div.className = "form-group row container-fluid justify-content-xl-between";

    var inner_div2 = document.createElement("div");
    inner_div2.className = "col-md-6";
    var inner_div21 = document.createElement("div");
    inner_div21.className = "col-md-6 form-check";

    var input_div2 = document.createElement("div");
    input_div2.className = "col-md-6";
    var input_div21 = document.createElement("div");
    input_div21.className = "col-md-6 form-check-input";

    var label2 = document.createElement("label");
    label2.innerText = "Answer name:"
    label2.className = "col-md-4 col-form-label text-md-right";
    label2.setAttribute("asp-for", "Name");

    var label21 = document.createElement("label");
    label21.innerText = "Is answer true?"
    label21.className = "col-md-4 col-form-label text-md-right";
    label21.setAttribute("asp-for", "IsTrue");

    var input2 = document.createElement("input");
    input2.type = "text";
    input2.setAttribute("asp-for", "Name");
    input2.name = "Questions[" + questionsCount + "].Answers[" + answersCount + "].Name";

    var input21 = document.createElement("input");
    input21.className = "form-check-input";
    input21.type = "checkbox";
    input21.setAttribute("value", "true");
    input21.setAttribute("asp-for", "IsTrue");
    input21.name = "Questions[" + questionsCount + "].Answers[" + answersCount + "].IsTrue";

    input_div2.appendChild(input2);
    input_div21.appendChild(input21);
    inner_div2.appendChild(label2);
    inner_div2.appendChild(input2);
    inner_div21.appendChild(label21);
    inner_div21.appendChild(input21);
    div.appendChild(inner_div2);
    div.appendChild(inner_div21);



    document.getElementById("answers").appendChild(div);

    if (answersCount >= 2) {
        var button = document.getElementById("questionButton");
        button.hidden = false;
    }
}
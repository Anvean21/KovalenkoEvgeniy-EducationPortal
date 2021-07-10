// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function CreateQuestion() {


    questionDiv = document.createElement("div");
    let questionCounter = document.getElementById("Info").childElementCount;
    let quesId = "Question" + questionCounter;
    questionDiv.id = quesId;

    let InfoQuesCount = parseInt(document.getElementById("Info").childElementCount);

    if (InfoQuesCount >= 1) {
        var qid = questionCounter - 1;
        var qidd = "Question" + qid;
        var oldDiv = document.getElementById(qidd);
        oldDiv.hidden = true;
    }

    var questionLabel = document.createElement("label");
    let questionNumber = questionCounter + 1;
    questionLabel.innerText = "Question " + questionNumber + " name:"
    questionLabel.className = "col-md-4 col-form-label text-md-right";
    questionLabel.setAttribute("asp-for", "Name");

    var questionInput = document.createElement("input");
    questionInput.type = "text";
    questionInput.setAttribute("asp-for", "Name");
    questionInput.className = "col-md-4 form-group";
    questionInput.name = "Questions[" + questionCounter + "].Name";

    var answerButton = document.createElement("button");
    answerButton.setAttribute("type", "button");
    answerButton.setAttribute("onclick", "AddAnswer()");
    answerButton.setAttribute("class", "btn btn-success ");
    answerButton.setAttribute("id", "AnswerButton");
    answerButton.style = "margin-left:5px";
    answerButton.innerHTML = 'Add New Answer';

    questionDiv.appendChild(questionLabel);
    questionDiv.appendChild(questionInput);
    questionDiv.appendChild(answerButton);

    document.getElementById("Info").appendChild(questionDiv);
}

function AddAnswer() {
    let InfoQuesCount = parseInt(document.getElementById("Info").childElementCount) - 1;

    var questionCounter = document.getElementById("Info").childElementCount - 1;
    var quesId = "Question" + questionCounter;

    var AnswerAppendDiv = document.getElementById(quesId);

    answerDiv = document.createElement("div");
    let answerCounter = document.getElementById(quesId).childElementCount - 3;
    let answerCount = document.getElementById(quesId).childElementCount - 3 + 1;
    let ansId = "Answer" + answerCounter;
    answerDiv.id = ansId;
    var answerNameLabel = document.createElement("label");

    answerNameLabel.innerText = "Answer " + answerCount + ":"
    answerNameLabel.className = "col-md-4 col-form-label text-md-right";
    answerNameLabel.setAttribute("asp-for", "Name");

    var answerNameInput = document.createElement("input");
    answerNameInput.type = "text";
    answerNameInput.setAttribute("asp-for", "Name");
    answerNameInput.name = "Questions[" + InfoQuesCount + "].Answers[" + answerCounter + "].Name";

    var answerIsTrueLabel = document.createElement("label");
    answerIsTrueLabel.innerText = "Is answer true?"
    answerIsTrueLabel.className = "col-md-4 col-form-label text-md-right";
    answerIsTrueLabel.setAttribute("asp-for", "IsTrue");

    var answerIsTrueInput = document.createElement("input");
    answerIsTrueInput.className = "form-check-input";
    answerIsTrueInput.type = "checkbox";
    answerIsTrueInput.setAttribute("value", "true");
    answerIsTrueInput.setAttribute("asp-for", "IsTrue");
    answerIsTrueInput.style = "margin-left:5px";
    answerIsTrueInput.name = "Questions[" + InfoQuesCount + "].Answers[" + answerCounter + "].IsTrue";

    answerDiv.appendChild(answerNameLabel);
    answerDiv.appendChild(answerNameInput);
    answerDiv.appendChild(answerIsTrueLabel);
    answerDiv.appendChild(answerIsTrueInput);

    AnswerAppendDiv.appendChild(answerDiv);
}
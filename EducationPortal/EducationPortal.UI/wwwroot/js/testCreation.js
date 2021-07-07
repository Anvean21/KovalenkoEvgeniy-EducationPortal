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
    questionInput.name = "Questions[" + questionCounter + "].Name";

    var answerButton = document.createElement("button");
    answerButton.setAttribute("type", "button");
    answerButton.setAttribute("onclick", "AddAnswer()");
    answerButton.setAttribute("class", "btn btn-primary");
    answerButton.setAttribute("id", "AnswerButton");
    answerButton.innerHTML = 'Add New Answer';

    questionDiv.appendChild(questionLabel);
    questionDiv.appendChild(questionInput);
    questionDiv.appendChild(answerButton);

    document.getElementById("Info").appendChild(questionDiv);
}



function AddAnswer() {
    let InfoQuesCount = parseInt(document.getElementById("Info").childElementCount)-1;

    var questionCounter = document.getElementById("Info").childElementCount-1;
    var quesId = "Question" + questionCounter;

    var AnswerAppendDiv = document.getElementById(quesId);

    answerDiv = document.createElement("div");


    if (AnswerAppendDiv.childElementCount == 3) {
        var answId = "Answer0";
        let answerCounter = 0;
        answerDiv.id = answId;
        var answerNameLabel = document.createElement("label");

        answerNameLabel.innerText = "Answer name:"
        answerNameLabel.className = "col-md-4 col-form-label text-md-right";
        answerNameLabel.setAttribute("asp-for", "Name");

        var answerIsTrueLabel = document.createElement("label");
        answerIsTrueLabel.innerText = "Is answer true?"
        answerIsTrueLabel.className = "col-md-4 col-form-label text-md-right";
        answerIsTrueLabel.setAttribute("asp-for", "IsTrue");

        var answerNameInput = document.createElement("input");
        answerNameInput.type = "text";
        answerNameInput.setAttribute("asp-for", "Name");
        answerNameInput.name = "Questions[" + InfoQuesCount + "].Answers[" + answerCounter + "].Name";

        var answerIsTrueInput = document.createElement("input");
        answerIsTrueInput.className = "form-check-input";
        answerIsTrueInput.type = "checkbox";
        answerIsTrueInput.setAttribute("value", "true");
        answerIsTrueInput.setAttribute("asp-for", "IsTrue");
        answerIsTrueInput.name = "Questions[" + InfoQuesCount + "].Answers[" + answerCounter + "].IsTrue";

        answerDiv.appendChild(answerNameLabel);
        answerDiv.appendChild(answerNameInput);
        answerDiv.appendChild(answerIsTrueLabel);
        answerDiv.appendChild(answerIsTrueInput);

        AnswerAppendDiv.appendChild(answerDiv);
    }

    else {
        let answerCounter = document.getElementById(quesId).childElementCount-3;
        let ansId = "Answer" + answerCounter;
        answerDiv.id = ansId;
        var answerNameLabel = document.createElement("label");

        answerNameLabel.innerText = "Answer name:"
        answerNameLabel.className = "col-md-4 col-form-label text-md-right";
        answerNameLabel.setAttribute("asp-for", "Name");

        var answerIsTrueLabel = document.createElement("label");
        answerIsTrueLabel.innerText = "Is answer true?"
        answerIsTrueLabel.className = "col-md-4 col-form-label text-md-right";
        answerIsTrueLabel.setAttribute("asp-for", "IsTrue");

        var answerNameInput = document.createElement("input");
        answerNameInput.type = "text";
        answerNameInput.setAttribute("asp-for", "Name");
        answerNameInput.name = "Questions[" + InfoQuesCount + "].Answers[" + answerCounter + "].Name";

        var answerIsTrueInput = document.createElement("input");
        answerIsTrueInput.className = "form-check-input";
        answerIsTrueInput.type = "checkbox";
        answerIsTrueInput.setAttribute("value", "true");
        answerIsTrueInput.setAttribute("asp-for", "IsTrue");
        answerIsTrueInput.name = "Questions[" + InfoQuesCount + "].Answers[" + answerCounter + "].IsTrue";

        answerDiv.appendChild(answerNameLabel);
        answerDiv.appendChild(answerNameInput);
        answerDiv.appendChild(answerIsTrueLabel);
        answerDiv.appendChild(answerIsTrueInput);

        AnswerAppendDiv.appendChild(answerDiv);
    }

}
//    var answerDivId = "Question" + document.getElementById("Info").childElementCount;
//    document.getElementById(answerDivId);
//    var answersCount = document.getElementById("answers").childElementCount;
//    var questionsCount = document.getElementById("questions").childElementCount - 1;

//    var div = document.createElement("div");
//    div.className = "form-group row container-fluid justify-content-xl-between";

//    var inner_div2 = document.createElement("div");
//    inner_div2.className = "col-md-6";
//    var inner_div21 = document.createElement("div");
//    inner_div21.className = "col-md-6 form-check";

//    var input_div2 = document.createElement("div");
//    input_div2.className = "col-md-6";
//    var input_div21 = document.createElement("div");
//    input_div21.className = "col-md-6 form-check-input";

//    var label2 = document.createElement("label");
//    label2.innerText = "Answer name:"
//    label2.className = "col-md-4 col-form-label text-md-right";
//    label2.setAttribute("asp-for", "Name");

//    var label21 = document.createElement("label");
//    label21.innerText = "Is answer true?"
//    label21.className = "col-md-4 col-form-label text-md-right";
//    label21.setAttribute("asp-for", "IsTrue");

//    var input2 = document.createElement("input");
//    input2.type = "text";
//    input2.setAttribute("asp-for", "Name");
//    input2.name = "Questions[" + questionsCount + "].Answers[" + answersCount + "].Name";

//    var input21 = document.createElement("input");
//    input21.className = "form-check-input";
//    input21.type = "checkbox";
//    input21.setAttribute("value", "true");
//    input21.setAttribute("asp-for", "IsTrue");
//    input21.name = "Questions[" + questionsCount + "].Answers[" + answersCount + "].IsTrue";

//    input_div2.appendChild(input2);
//    input_div21.appendChild(input21);
//    inner_div2.appendChild(label2);
//    inner_div2.appendChild(input2);
//    inner_div21.appendChild(label21);
//    inner_div21.appendChild(input21);
//    div.appendChild(inner_div2);
//    div.appendChild(inner_div21);



//    document.getElementById("answers").appendChild(div);

//    if (answersCount >= 1) {
//        var button = document.getElementById("questionButton");
//        button.hidden = false;
//    }
//}

//function AddQuestion() {
    
//    var questionsCount = parseInt(document.getElementById("questions").childElementCount);

//    if (questionsCount > 1) {
//        var oldDiv = document.getElementById(questionsCount - 2);
//        oldDiv.hidden = true;
//    }
   
//    //var button = document.getElementById("questionButton");
//    //button.hidden = true;

//    var answerButton = document.createElement("button");
//    answerButton.setAttribute("type", "button");
//    answerButton.setAttribute("onclick", "AddAnswer()");
//    answerButton.setAttribute("class", "btn btn-primary");
//    answerButton.setAttribute("id", "AnswerButton");
//    answerButton.innerHTML = 'Add New Answer';

//    var answers = document.createElement("div");
//    answers.id = "answers";

//    var div = document.createElement("div");
//    div.className = "form-group row container-fluid justify-content-xl-between";
//    div.id = questionsCount - 1;

//    let qustionNumber = questionsCount - 1;
//    var label1 = document.createElement("label");
//    label1.innerText = "Question " + questionsCount+" name:"
//    label1.className = "col-md-4 col-form-label text-md-right";
//    label1.setAttribute("asp-for", "Name");

//    var input_div1 = document.createElement("div");
//    input_div1.className = "col-md-6";

//    var inner_div1 = document.createElement("div");
//    inner_div1.className = "col-md-6";

//    var input1 = document.createElement("input");
//    input1.type = "text";
//    input1.setAttribute("asp-for", "Name");
//    input1.name = "Questions[" + qustionNumber + "].Name";

//    input_div1.appendChild(input1);
//    inner_div1.appendChild(label1);
//    inner_div1.appendChild(input1);
//    inner_div1.appendChild(answerButton)


//    //cоздаем нашу херень
//    div.appendChild(inner_div1);
//    //вставляем в наш прописаный див вопрос
//    document.getElementById("questions").appendChild(div);
//    document.getElementById("answers").append(answers);
//}


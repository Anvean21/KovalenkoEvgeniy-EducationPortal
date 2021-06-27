// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () { 
    document.querySelectorAll('input , select').forEach(function (e) {
       
        if (e.value === '') e.value = window.sessionStorage.getItem(e.name, e.value);
      
        e.addEventListener('input', function () {
            window.sessionStorage.setItem(e.name, e.value);
        })
    })
}); 
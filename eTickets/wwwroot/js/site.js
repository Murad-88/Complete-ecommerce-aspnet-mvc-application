// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*(Start)  click event on the "Redeem" button. When the button is clicked, */
const redeemBtn = document.getElementById('redeemBtn');
const arrowIcon = document.getElementById('arrowIcon');

redeemBtn.addEventListener('click', function () {
    redeemBtn.classList.add('btn-redeemed');
    arrowIcon.style.display = 'inline-block';
});
/*(End)  click event on the "Redeem" button. When the button is clicked, */

/*(Start)  click event on the Multi Carousel. , */
let items = document.querySelectorAll('.carousel .carousel-item')

items.forEach((el) => {
    const minPerSlide = 4
    let next = el.nextElementSibling
    for (var i = 1; i < minPerSlide; i++) {
        if (!next) {
            // wrap carousel by using first child
            next = items[0]
        }
        let cloneChild = next.cloneNode(true)
        el.appendChild(cloneChild.children[0])
        next = next.nextElementSibling
    }
})
/*(End)  click event on the Multi Carousel. , */

// Get all project images by their class name
const projectImages = document.querySelectorAll('.project-img');

// greyscale
function applyGreyscale() {
    projectImages.forEach((image) => {
        image.style.filter = 'grayscale(100%)'; // Apply greyscale
    });
}

// onHover- remove greyscale
function removeGreyscale(event) {
    event.target.style.filter = 'none'; // Remove greyscale on hover
}

//Eventlistener- toggle greyscale
projectImages.forEach((image) => {
    image.addEventListener('mouseenter', removeGreyscale);
    image.addEventListener('mouseleave', applyGreyscale);
});

// initially...
applyGreyscale();
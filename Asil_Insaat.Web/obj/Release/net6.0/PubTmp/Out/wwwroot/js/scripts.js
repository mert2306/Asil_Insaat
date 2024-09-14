document.addEventListener("DOMContentLoaded", function () {
    const lightbox = document.getElementById('lightbox');
    const lightboxContent = document.querySelector('.lightbox-content');
    const closeBtn = document.querySelector('.close-btn');
    const videos = document.querySelectorAll('.lightbox');

    videos.forEach(video => {
        video.addEventListener('click', function (event) {
            event.preventDefault();
            const videoUrl = this.getAttribute('href');
            openLightbox(videoUrl);
        });
    });

    closeBtn.addEventListener('click', closeLightbox);

    lightbox.addEventListener('click', function (event) {
        if (event.target === lightboxContent || event.target === lightbox) {
            closeLightbox();
        }
    });

    function openLightbox(videoUrl) {
        lightbox.style.display = 'flex';
        document.getElementById('video-frame').setAttribute('src', videoUrl);
        document.body.style.overflow = 'hidden'; // Body scrollunu gizle
    }

    function closeLightbox() {
        lightbox.style.display = 'none';
        document.getElementById('video-frame').setAttribute('src', '');
        document.body.style.overflow = ''; // Body scrollunu geri getir
    }
});

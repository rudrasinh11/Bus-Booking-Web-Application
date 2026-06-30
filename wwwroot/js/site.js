document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll(".btn").forEach((button) => {
        button.addEventListener("click", (event) => {
            const circle = document.createElement("span");
            const diameter = Math.max(button.clientWidth, button.clientHeight);
            const radius = diameter / 2;
            const rect = button.getBoundingClientRect();

            circle.style.width = circle.style.height = `${diameter}px`;
            circle.style.left = `${event.clientX - rect.left - radius}px`;
            circle.style.top = `${event.clientY - rect.top - radius}px`;
            circle.classList.add("ripple");

            const existing = button.querySelector(".ripple");
            if (existing) {
                existing.remove();
            }

            button.appendChild(circle);
        });
    });

    const revealItems = document.querySelectorAll(".reveal");
    if (!revealItems.length) {
        return;
    }

    const observer = new IntersectionObserver((entries) => {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                entry.target.classList.add("is-visible");
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.12 });

    revealItems.forEach((item) => observer.observe(item));
});

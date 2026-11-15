// The only JavaScript in the project: puts the "country" classes and colors on <body>,
// because a Blazor component cannot style <body> itself.
window.travelTheme = {
    reset: function () {
        const b = document.body;
        if (b.dataset.country) {
            b.classList.remove(b.dataset.country);
            delete b.dataset.country;
        }
        b.style.removeProperty("--accent");
        b.style.removeProperty("--hero-bg");
        b.style.removeProperty("--hero-glow");
    },

    // a real country: body gets "country" + the country key and the three color variables
    set: function (key, accent, heroBg, heroGlow) {
        window.travelTheme.reset();
        const b = document.body;
        b.classList.add("country", key);
        b.dataset.country = key;
        b.style.setProperty("--accent", accent);
        b.style.setProperty("--hero-bg", heroBg);
        b.style.setProperty("--hero-glow", heroGlow);
    },

    // the flag picker: only the "country" class, no colors
    picker: function () {
        window.travelTheme.reset();
        document.body.classList.add("country");
    },

    // leaving the country page: remove everything
    leave: function () {
        window.travelTheme.reset();
        document.body.classList.remove("country");
    }

};

// small helpers used by the Plan and Games pages
window.travelUi = {
    focusId: function (id) {
        const el = document.getElementById(id);
        if (el) el.focus();
    },
    scrollToId: function (id, offset) {
        const el = document.getElementById(id);
        if (el) {
            window.scrollTo({ top: el.getBoundingClientRect().top + window.scrollY - (offset || 0), behavior: "smooth" });
        }
    },
    scrollTop: function () {
        window.scrollTo({ top: 0, behavior: "smooth" });
    }
};
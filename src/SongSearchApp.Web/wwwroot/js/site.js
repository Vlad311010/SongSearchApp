(function () {
	var key = "songSearch.scrollY";
	var triggers = document.querySelectorAll("[data-scroll-restore='true']");
	for (var i = 0; i < triggers.length; i++) {
		triggers[i].addEventListener("click", function () {
			sessionStorage.setItem(key, String(window.scrollY));
		});
	}

	if ("scrollRestoration" in history) {
		history.scrollRestoration = "manual";
	}

	var params = new URLSearchParams(window.location.search);
	var offset = Number(params.get("Offset") || "0");
	var saved = sessionStorage.getItem(key);
	if (saved && offset > 0) {
		sessionStorage.removeItem(key);
		var y = Number(saved);
		if (!Number.isNaN(y)) {
			requestAnimationFrame(function () {
				requestAnimationFrame(function () {
					window.scrollTo({ top: y, left: 0, behavior: "auto" });
				});
			});
		}
	}

	var loadMore = document.querySelector("[data-load-more='true']");
	if (loadMore) {
		loadMore.addEventListener("click", function (event) {
			if (!window.fetch) {
				return;
			}

			event.preventDefault();
			var target = document.getElementById("results-items");
			if (!target) {
				window.location.href = loadMore.href;
				return;
			}

			loadMore.setAttribute("aria-busy", "true");
			loadMore.classList.add("disabled");

			fetch(loadMore.href, {
				headers: { "X-Requested-With": "XMLHttpRequest" }
			})
				.then(function (response) {
					if (!response.ok) {
						throw new Error("Request failed");
					}
					return Promise.all([response.text(), response.headers]);
				})
				.then(function (result) {
					var html = result[0];
					var headers = result[1];
					target.insertAdjacentHTML("beforeend", html);

					var hasMore = headers.get("X-Has-More") === "true";
					var nextOffset = headers.get("X-Next-Offset");
					if (!hasMore || !nextOffset) {
						loadMore.remove();
						return;
					}

					var url = new URL(loadMore.href, window.location.origin);
					url.searchParams.set("Offset", nextOffset);
					loadMore.href = url.toString();
				})
				.catch(function () {
					window.location.href = loadMore.href;
				})
				.finally(function () {
					if (loadMore.isConnected) {
						loadMore.removeAttribute("aria-busy");
						loadMore.classList.remove("disabled");
					}
				});
		});
	}
})();

const API_BASE = "https://localhost:5025"; // ajuste para a porta da sua API

async function loadBooks(type = "title", value = "") {
    const url = new URL(`${API_BASE}/api/books/search`);
    url.searchParams.append("type", type);
    url.searchParams.append("value", value);

    const res = await fetch(url);
    if (!res.ok) throw new Error(res.statusText);
    const data = await res.json();

    const tbody = document.getElementById("results");
    tbody.innerHTML = "";

    data.forEach(b => {
        const tr = document.createElement("tr");
        tr.innerHTML = `
      <td>${b.title}</td>
      <td>${b.firstName}</td>
      <td>${b.lastName}</td>
      <td>${b.totalCopies}</td>
      <td>${b.copiesInUse}</td>
      <td>${b.type}</td>
      <td>${b.isbn}</td>
      <td>${b.category}</td>
    `;
        tbody.appendChild(tr);
    });
}

// Carrega todos ao iniciar
window.addEventListener("DOMContentLoaded", () => loadBooks());

// Busca ao clicar no botão
document.getElementById("searchBtn").addEventListener("click", () => {
    const type = document.getElementById("searchBy").value;
    const value = document.getElementById("searchValue").value;
    loadBooks(type, value);
});

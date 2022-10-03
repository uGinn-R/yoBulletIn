document.getElementById("itemsBtn").addEventListener("click", function (event) {
    $('#RenderZone').load("/UserProfile/ItemsPartial")
});

document.getElementById("messagesBtn").addEventListener("click", function (event) {
    $('#RenderZone').load("/UserProfile/MessagesPartial")
});
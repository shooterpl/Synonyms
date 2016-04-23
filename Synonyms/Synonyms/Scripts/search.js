var url = '/api/Search';

function searching() {
    //data = $('#synonym').val().toString();
    data = {
        Type: "SynonymDtoViewModel",
        Term: $('#synonym').val().toString(),
        Synonyms: "lol"
    };
    $.post(url, data, function (item) {
            for (i = 0; i < item.Synonyms.length ; i++) {
                $('.synonym-list').after("<span class='list'>" + item.Synonyms[i] + "</span>");
            }
            $('.synonym-list').after("<div class='term'>" + item.Term + "</div>");
        });
        //$('.synonym-list').after("<span class='list'>" + item.Synonyms + "</span>");
        //$('.synonym-list').after("<div class='term'>" + item.Term + "</div>");

 
}
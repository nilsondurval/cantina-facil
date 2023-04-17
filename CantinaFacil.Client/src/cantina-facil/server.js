let express = require('express');

let app = express();

app.use(express.static(__dirname + '/dist/cantina-facil'));

app.get('/*', (req, resp) => {
    resp.sendFile(__dirname + '/dist/cantina-facil/index.html');
});

app.listen(process.env.PORT || 8080);
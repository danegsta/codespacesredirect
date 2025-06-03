const http = require('http');

const server = http.createServer((req, res) => {
  console.log(`Received request for: ${req.url}`);

  if (req.url === '/' || req.url === '') {
    // Redirect root to /bad
    res.writeHead(302, { 'Location': '/bad' });
    res.end();
  } else if (req.url === '/hello') {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.end('hello world');
  } else if (req.url === '/good') {
    // Redirect to relative path
    res.writeHead(302, { 'Location': '/hello' });
    res.end();
  } else if (req.url === '/bad') {
    // Redirect to absolute URL
    res.writeHead(302, { 'Location': 'http://localhost:8000/hello' });
    res.end();
  } else {
    res.writeHead(404, { 'Content-Type': 'text/plain' });
    res.end('Not Found');
  }
});

const PORT = 8000;
server.listen(PORT, () => {
  console.log(`Server running at http://localhost:${PORT}/`);
});

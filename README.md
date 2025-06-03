# Minimal Codespaces redirect issue reproduction

## Steps to reproduce
1. Open this project in an in browser Codespace instance (doesn't reproduce if running via VSCode remoting).
2. Run the `index.js` file.
3. Open the redirect URL in a browser.
4. Observe that the redirect URL ended up with port :8000.
5. The /bad endpoint does an absolute redirection to http://localhost:8000/hello and shows the bad redirect behavior.
6. The /good endpoint does a relative redirection to /hello and the redirect works as expected.

## Expected behavior
An absolute redirect to http://localhost:8000/hello should have the redirect URL rewritten without the 8000 port.

## Actual behavior
The redirect URL ends up with port :8000, which isn't valid in codespaces.

This reproduces for a number of different ports, not just 8000 (5000, 3000, etc).
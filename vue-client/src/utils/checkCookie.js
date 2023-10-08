import Cookies from 'js-cookie';

export function checkAuthenticationCookie() {
  const jwtCookie = Cookies.get('jwt'); // Replace 'jwt' with your cookie name
  // Implement logic to validate the token and its expiration
  // Return true if valid, false otherwise
  return jwtCookie !== undefined;
}
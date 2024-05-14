export const dev = window.location.origin.includes('localhost')

// NOTE don't forget to change your baseURL if using the dotnet template
export const baseURL = dev ? 'https://localhost:7045' : ''
export const useSockets = false

// TODO change these variables out to your own auth after cloning!
export const domain = 'dev-igepbtkmc1ba5lje.us.auth0.com'
export const clientId = 'aeNaB4HPylNWypTUZCNFcKeYzOVpjfx3'
export const audience = 'https://houses.com'
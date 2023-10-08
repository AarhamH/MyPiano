export async function makeApiRequest(url, options) {
  try {
    const response = await fetch(url, options);
    let responseFlag = response.ok;
    if (!response.ok) {
    }

    let responseData;

    // Check the Content-Type header
    const contentType = response.headers.get("content-type");
    if (contentType && contentType.includes("application/json")) {
      responseData = await response.json();
    } else {
      // Handle non-JSON responses differently if needed
      responseData = await response.text(); // or response.blob() for binary data
    }

    return { responseFlag, responseData };
  } catch (error) {
    throw error;
  }
}

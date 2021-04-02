export async function handleResponse(response: any) {
  if (response.status === 200 || response.status === 201) {
    return response.data;
  }
  if (response.status === 400 || response.status === 404) {
    const error = await response.text();
    throw new Error(error);
  }
  if (response.status === 500)
    throw new Error("Something went wrong! 500 internal server error!");

  throw new Error(`Network response was not ok. ${response.status}`);
}

// In a real app, would likely call an error logging service.
export function handleError(error: any) {
  if (error.response.status === 403)
    throw new Error(`Unauthorized access! ${error.response.status}`);

  if (error.response.status === 500)
    throw new Error("Something went wrong! 500 internal server error!");

  throw error;
}

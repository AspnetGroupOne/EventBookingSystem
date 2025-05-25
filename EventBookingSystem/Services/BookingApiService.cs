using EventBookingSystem.DTOs;

public class BookingApiService
{
    private readonly HttpClient _httpClient;

    public BookingApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
    {
        var response = await _httpClient.GetAsync("/api/Booking");
        response.EnsureSuccessStatusCode();

        var bookings = await response.Content.ReadFromJsonAsync<IEnumerable<BookingDTO>>();
        return bookings!;
    }

    public async Task<BookingDTO?> CreateBookingAsync(CreateBookingDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/Booking", dto);

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<BookingDTO>();
    }
}

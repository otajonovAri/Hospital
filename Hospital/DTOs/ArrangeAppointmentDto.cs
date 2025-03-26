namespace Hospital.DTOs;

public class ArrangeAppointmentDto
{
    public int PatientId { get; set; }

    public string PassportSerial { get; set; }

    public DateTime AppointmentDate { get; set; }
}

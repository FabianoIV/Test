using Radzen;

namespace Grafik.Services;

public interface ICustomNotificationsService
{
    #region Common Notifications
    void SendAuthorizationMissingNotification();
    void SendAdministratorRoleMissingNotification();
    void SendErrorNotification(string message);
    #endregion

    #region PlanningSession Notifications
    void SendPlanningSessionCreateErrorNotification();
    void SendPlanningSessionCreateSucessNotification();
    public void SendPlanningSessionDeleteSuccessNotification();
    public void SendPlanningSessionDeleteErrorNotification();
    public void SendPlanningSessionUpdateSuccessNotification();
    public void SendPlanningSessionUpdateErrorNotification();
    #endregion

    #region ExcludedTime Notifications
    void SendExcludedTimeUpdateSuccessNotification();
    void SendExcludedTimeUpdateErrorNotification();
    void SendExcludedTimeDeleteErrorNotification();
    void SendExcludedTimeDeleteSuccessNotification();
    void SendExcludedTimeErrorNotification();
    void SendExcludedTimeSucessNotification();
    #endregion


    #region Reservation Notifications
    void SendEditReservationErrorNotification();
    void SendNotReservationOwnerNotification();
    void SendReservationDeleteSuccessNotification();
    void SendReservationDeleteErrorNotification();
    void SendReservationCreateSuccessNotification();
    void SendEditReservationSuccessNotification();
    void SendReservationAlreadyExistsNotification();
    #endregion

    #region PlannerUser Notifications
    void SendUserCreatedErrorNotification();
    void SendUserCreatedSucessNotification();
    void SendUserRemoveSuccessNotification();
    void SendUserRemoveErrorNotification();
    void SendUserUpdateErrorNotification();
    void SendUserUpdateSuccessNotification();
    #endregion

    void SendSessionNotActiveNotification();
}

public class CustomNotificationsService : ICustomNotificationsService
{
    private NotificationService _notificationService;

    public CustomNotificationsService(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    #region Common Notifications

    public void SendAuthorizationMissingNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Warning,
            Summary = "Brak autoryzacji",
            Detail = "Nie jesteś zalogowany. Proszę się zalogować, aby kontynuować."
        });
    }

    public void SendAdministratorRoleMissingNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Warning,
            Summary = "Brak autoryzacji",
            Detail = "Brak uprawnień do wykonania tej operacji."
        });
    }

    public void SendErrorNotification(string message)
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = $"Wystąpił błąd: {message}"
        });
    }

    #endregion

    public void SendSessionNotActiveNotification(){
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Warning,
            Summary = "Sesja nieaktywna",
            Detail = "Nie można dodawać rezerwacji do nieaktywnej sesji. Zapytaj administratora."
        });
    }

    #region PlanningSession Notifications

    public void SendPlanningSessionCreateErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się dodać sesji planowania"
        });
    }

    public void SendPlanningSessionCreateSucessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Dodano sesję planowania"
        });
    }

    public void SendPlanningSessionDeleteSuccessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Usunięto sesję planowania"
        });
    }

    public void SendPlanningSessionDeleteErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się usunąć sesji planowania"
        });
    }

    public void SendPlanningSessionUpdateSuccessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Zaktualizowano sesję planowania"
        });
    }

    public void SendPlanningSessionUpdateErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się zaktualizować sesji planowania"
        });
    }

    #endregion

    #region ExcludedTime Notifications

    public void SendExcludedTimeUpdateSuccessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Zaktualizowano wykluczone godziny"
        });
    }

    public void SendExcludedTimeUpdateErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się zaktualizować wykluczonych godzin"
        });
    }

    public void SendExcludedTimeDeleteErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się usunąć wykluczonych godzin"
        });
    }

    public void SendExcludedTimeDeleteSuccessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Usunięto wykluczone godziny"
        });
    }

    public void SendExcludedTimeErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się utworzyć wykluczenia"
        });
    }

    public void SendExcludedTimeSucessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Dodano wykluczenie"
        });
    }
    #endregion

    #region Reservation Notifications
    public void SendEditReservationErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się zaktualizować rezerwacji"
        });
    }

    public void SendNotReservationOwnerNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Warning,
            Summary = "Brak autoryzacji",
            Detail = "Nie jesteś właścicielem tej rezerwacji"
        });
    }

    public void SendReservationDeleteSuccessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Usunięto rezerwację"
        });
    }

    public void SendReservationDeleteErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się usunąć rezerwacji"
        });
    }

    public void SendReservationCreateSuccessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Dodano rezerwację"
        });
    }

    public void SendEditReservationSuccessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Zaktualizowano rezerwację"
        });
    }

    public void SendReservationAlreadyExistsNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Warning,
            Summary = "Błąd",
            Detail = "Rezerwacja już istnieje"
        });
    }
    #endregion

    #region PlannerUser Notifications
    public void SendUserCreatedErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się dodać użytkownika"
        });
    }

    public void SendUserCreatedSucessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Dodano użytkownika"
        });
    }

    public void SendUserRemoveSuccessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Usunięto użytkownika"
        });
    }

    public void SendUserRemoveErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się usunąć użytkownika"
        });
    }

    public void SendUserUpdateErrorNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Błąd",
            Detail = "Nie udało się zaktualizować użytkownika"
        });
    }

    public void SendUserUpdateSuccessNotification()
    {
        _notificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Success,
            Summary = "Sukces",
            Detail = "Zaktualizowano użytkownika"
        });
    }
    #endregion
}

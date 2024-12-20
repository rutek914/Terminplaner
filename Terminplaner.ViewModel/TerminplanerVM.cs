﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using Terminplaner.Model.Entities;
using Terminplaner.Model.Enums;
using Terminplaner.Service;

namespace Terminplaner.ViewModel {
    public class TerminplanerVM : NotifyBase
    {
        private readonly AppointmentService _appointmentService;
        private readonly UserService _userService;

        public ObservableCollection<Appointment> Appointments { get; } = new ObservableCollection<Appointment>();
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

        private Appointment? _selectedAppointment;
        public Appointment? SelectedAppointment
        {
            get => _selectedAppointment;
            set => SetProperty(ref _selectedAppointment, value);
        }

        private string _newTitle = string.Empty;
        public string NewTitle
        {
            get => _newTitle;
            set => SetProperty(ref _newTitle, value);
        }

        private string _newDescription = string.Empty;
        public string NewDescription
        {
            get => _newDescription;
            set => SetProperty(ref _newDescription, value);
        }

        private DateTime? _newStartTime = DateTime.Now;
        public DateTime? NewStartTime
        {
            get => _newStartTime;
            set => SetProperty(ref _newStartTime, value);
        }

        private DateTime? _newEndTime = DateTime.Now.AddHours(1);
        public DateTime? NewEndTime
        {
            get => _newEndTime;
            set => SetProperty(ref _newEndTime, value);
        }

        private User? _selectedUser;
        public User? SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value);
        }

        private string _newUserName = string.Empty;
        public string NewUserName 
        {
            get => _newUserName;
            set => SetProperty(ref _newUserName, value);
        }

        public ICommand AddAppointmentCommand { get; }
        public ICommand DeleteAppointmentCommand { get; }

        public ICommand AddNewUserCommand { get; }

        public ICommand DeleteUserCommand { get; }

        public TerminplanerVM(AppointmentService appointmentService, UserService userService)
        {
            _appointmentService = appointmentService;
            _userService = userService;

            AddAppointmentCommand = new RelayCommand(async _ => await AddAppointment(), _ => CanAddAppointment());
            DeleteAppointmentCommand = new RelayCommand(async _ => await DeleteAppointment(), _ => SelectedAppointment != null);
            AddNewUserCommand = new RelayCommand(async _ => await AddNewUser());
            DeleteUserCommand = new RelayCommand(async _ => await DeleteUser());

            LoadData();
        }

        private async Task DeleteUser() {
            var users = await _userService.GetAllUsersAsync();

            foreach (var user in users) {
                if (user.Username == NewUserName) {
                    Users.Remove(user);
                    await _userService.DeleteUserAsync(user);
                }
            }
        }

        private async Task AddNewUser() {
            var users = await _userService.GetAllUsersAsync();

            var user = new User() {
                Id = Guid.NewGuid(),
                Email = "test.com",
                PasswordHash = "passwort",
                Role = UserRole.Employee,
                Username = NewUserName
            };
            Users.Add(user);

            await _userService.CreateNewUserAsync(user);
        }

        private async void LoadData()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            Appointments.Clear();
            foreach (var appointment in appointments)
            {
                Appointments.Add(appointment);
            }

            var users = await _userService.GetAllUsersAsync();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        private bool CanAddAppointment()
        {
            return !string.IsNullOrWhiteSpace(NewTitle) && SelectedUser != null && NewEndTime > NewStartTime;
        }

        private async Task AddAppointment()
        {
            var newAppointment = new Appointment
            {
                Title = NewTitle,
                Description = NewDescription,
                StartTime = NewStartTime.Value,
                EndTime = NewEndTime.Value,
                Status = AppointmentStatus.Scheduled,
                UserId = SelectedUser!.Id 
            };

            await _appointmentService.AddAppointmentAsync(newAppointment);
            Appointments.Add(newAppointment);

            NewTitle = string.Empty;
            NewDescription = string.Empty;
            NewStartTime = DateTime.Now;
            NewEndTime = DateTime.Now.AddHours(1);
            SelectedUser = null;
        }

        private async Task DeleteAppointment()
        {
            if (SelectedAppointment != null)
            {
                await _appointmentService.DeleteAppointmentAsync(SelectedAppointment.Id);
                Appointments.Remove(SelectedAppointment);
            }
        }
    }
}

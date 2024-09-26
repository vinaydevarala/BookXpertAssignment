$(document).ready(function () {
    $(".delete").click(function () {
        var id = $(this).data("id");
        if (confirm("Are you sure to delete this employee?")) {
            window.location.href = "/Employee/Delete/" + id;
        }
    });

    $.get("/Employee/TotalSalary", function (data) {
        $("#totalSalary").text(data);
    });
    $(".edit").click(function () {
        var id = $(this).data("id");
        $.get("/employee/index/" + id, function (data) {
            $("#id").val(data.id);
            $("#name").val(data.name);
            $("#designation").val(data.designation);
            $("#dateofjoining").val(data.dateofjoining.split('t')[0]);
            $("#salary").val(data.salary);
            $("input[name='gender'][value='" + data.gender + "']").prop('checked', true);
            $("#state").val(data.state);
        });
    });
    function validateForm() {
        var isValid = true;
        // Example validation for name field
        // var errorMessages = [];// Clear previous error messages
        // document.getElementById("errorMessages").innerHTML = '';

        var Name = document.getElementById('Name').value;
        if (Name === '') {
            alert('First name is required.');
            isValid = false;
        }

        var Designation = document.getElementById('Designation').value;
        if (Designation === '') {
            alert('Designation is required.');
            isValid = false;
        }
        var Salary = document.getElementById('Salary').value;
        if (Salary === '') {
            alert('Salary is required.');
            isValid = false;
        }

        var dateString = document.getElementById('DateOfJoining').value;
        var date = new Date(dateString);

        // Check if the date is valid (the isNaN function returns true if the date is invalid)
        if (isNaN(date)) {
            alert("Invalid date of Joining. Please enter a valid date.");
            isValid = false;
        }

        var gender = document.querySelector('input[name="Gender"]:checked');
        if (!gender) {
            alert("Please select your gender.");
            isValid = false;
        }

        var State = document.getElementById("State").value;
        if (State === "") {
            alert("Please select a State.");
            isValid = false;
        }
        if (isValid) {
            return true;
        }
        return false;
    }
# LaptopCode

-<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>


-<select id="myDropdown">
- <option value="">-- Select --</option>
-</select>
-<script>
- $(document).ready(function () {
 -   $.ajax({
  -    type: "POST",
   -   url: "Default.aspx/GetMessage",
    -  data: '{}',
     - contentType: "application/json; charset=utf-8",
      -dataType: "json",
      -success: function (response) {
      -  var items = response.d;
      -  var $dropdown = $('#myDropdown');
      -  $.each(items, function (i, item) {
      -    $dropdown.append($('<option>', {
      -      value: item.Id,
      -      text: item.Name
      -    }));
      -  });
      -},
     - error: function (xhr) {
     -   if (xhr.status === 401) {
     -     alert("Unauthorized. Please log in.");
     -     window.location.href = "/Login.aspx";
     -   } else {
     -     alert("Error: " + xhr.statusText);
    -    }
    -  }
    -});
  -});
-</script>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafico_Cantidad_De_Productos.aspx.cs" Inherits="pruebaGrafico1.Grafico3YO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);
        //Productos vendidos
        function drawChart() {
            var data = google.visualization.arrayToDataTable(<%=ObtenerDatos()%>)
            
            //  ['fecha', 'ganancia'],
            //  ['23/08',    20],
            //  ['24/08',      30],
            //  ['25/08',  2],
            //  ['26/08', 1],
            //  ['27/08',    30]
            //]);

            var options = {
                title: 'Cantidad de productos vendidos'
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart'));

            chart.draw(data, options);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="piechart" style="width: 900px; height: 500px;"></div>
        </div>
    </form>
</body>
</html>

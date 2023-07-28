<?php
    include_once 'model/conexion.php';


    header('Content-Type: application/json; charset=utf-8');
if ($_SERVER['REQUEST_METHOD'] == 'GET')
{
    //if (isset($_GET['user']))
    //{
      //Mostrar un post
      $sql = $dbConn->prepare("SELECT * from usuario  where user=:user");
      $sql->bindValue(':codigo', $_GET['codigo']);
      $sql->execute();
      header("HTTP/1.1 200 OK");
      echo json_encode(  $sql->fetch(PDO::FETCH_ASSOC)  );
      exit();
	  //}
	/* else {
      //Mostrar lista de post
      $sql = $dbConn->prepare("SELECT * FROM estudiante");
      $sql->execute();
      $sql->setFetchMode(PDO::FETCH_ASSOC);
      header("HTTP/1.1 200 OK");
      echo json_encode( $sql->fetchAll());
      exit();
}*/
}

if ($_SERVER['REQUEST_METHOD'] == 'POST')
{
    $input = $_POST;
    $sql = "INSERT INTO usuario
          (user, pass, correo, rol, observaciones, lat, lng)
          VALUES
          (:user, :pass, :correo, :rol, :observaciones, :lat, :lng)";
    $statement = $dbConn->prepare($sql);
    bindAllValues($statement, $input);
    $statement->execute();

    $postCodigo = $dbConn->lastInsertId();
    if($postCodigo)
    {
      $input['codigo'] = $postCodigo;
      header("HTTP/1.1 200 OK");
      echo json_encode($input);
      exit();
  }
}
	if ($_SERVER['REQUEST_METHOD'] == 'DELETE')
{
	$codigo = $_GET['codigo'];
  $statement = $dbConn->prepare("DELETE FROM  estudiante where codigo=:codigo");
  $statement->bindValue(':codigo', $codigo);
  $statement->execute();
	header("HTTP/1.1 200 OK");
	exit();
}

if ($_SERVER['REQUEST_METHOD'] == 'PUT')
{
    $input = $_GET;
    $postCodigo = $input['user'];
    $fields = getParams($input);

    $sql = "
          UPDATE usuario
          SET $fields
          WHERE user='$postCodigo'
           ";

    $statement = $dbConn->prepare($sql);
    bindAllValues($statement, $input);

    $statement->execute();
    header("HTTP/1.1 200 OK");
    exit();
}
function getParams($input)
{
   $filterParams = [];
   foreach($input as $param => $value)
   {
           $filterParams[] = "$param=:$param";
   }
   return implode(", ", $filterParams);
 }

 //Asociar todos los parametros a un sql
 function bindAllValues($statement, $params)
 {
   foreach($params as $param => $value)
   {
       $statement->bindValue(':'.$param, $value);
   }
   return $statement;
  }
?>

<!-- ./README_dgv_main.md -->
Para resolver este error asegúrate de que en la clase del formulario exista la declaración y la creación del control:

1. **Declaración**
   En el archivo `main.Designer.vb`, debería aparecer algo como:
   ```vb
   Friend WithEvents dgv_main As System.Windows.Forms.DataGridView
   ```
   Esta línea declara el control dentro de la clase parcial generada por el diseñador.

2. **Instanciación**
   En la sección `InitializeComponent` (también en `main.Designer.vb`), normalmente se crea el control:
   ```vb
   Me.dgv_main = New System.Windows.Forms.DataGridView()
   ```

3. **Archivo principal de código**
   Verifica que tu clase principal (`main.vb`) sea la contraparte parcial de la clase del diseñador:
   ```vb
   Public Partial Class main
       ' ...
   End Class
   ```
   Si no está marcada con `Partial`, agrégalo para que el compilador combine ambas partes de la clase.

Con esas secciones en su lugar, el control `dgv_main` debería estar correctamente declarado y asignado, eliminando el mensaje "variable dgv_main is either undeclared or was never assigned".

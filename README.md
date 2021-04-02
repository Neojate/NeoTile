# NeoTile
Motor 2D para juegos basados en tiles bajo la librería MonoGame 3.8

## Instalación

Descargar el proyecto y compilarlo.

Copiar el dll, NeoTile.dll, creado en la carpeta NeoTile/bin/Debug.

Pegar en la carpeta bin del proyecto que se desee usar y añadirlo en las referencias.


## Uso - NeoTileMain

En la clase Game1 hay que crear una instancia de NeoTileMain pasándole como parámetro la resolución del juego en formato Vector2.

En la misma clase, en la función update, invocaremos el método update de la instancia de NeoTileMain. 

```
protected override void Update(GameTime gameTime)
{
  if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
    Exit();

  neoTileMain.Update();

  base.Update(gameTime);
}
```

Haremos lo mismo en el método Draw(), esta vez encapsuándolo en el begin(), end() y pasándole como parámetro el SpriteBatch.

```
protected override void Draw(GameTime gameTime)
{
  GraphicsDevice.Clear(Color.CornflowerBlue);

  spriteBatch.Begin();
  neoTileMain.Draw(spriteBatch);
  spriteBatch.End();

  base.Draw(gameTime);
}

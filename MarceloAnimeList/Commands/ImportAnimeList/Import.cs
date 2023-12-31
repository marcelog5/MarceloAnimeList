﻿using Common.DomainLayer.Command;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Service;
using System.Text;

namespace MarceloAnimeList.Commands.ImportAnimeList
{
    public class Import : ICLICommand
    {
        private readonly IFileService _fileService;

        public Import
        (
            IFileService fileService
        )
        {
            _fileService = fileService;
        }

        public void Execute(string[] args)
        {
            try
            {
                string filePath = args[1];

                // Verifique se o arquivo existe
                if (File.Exists(filePath))
                {
                    // Realize a leitura do arquivo
                    string content = File.ReadAllText(filePath, Encoding.GetEncoding("ISO-8859-1"));

                    List<Media> medias = _fileService.Parser(content);

                    // Exiba o conteúdo do arquivo
                    Console.WriteLine("Conteúdo do arquivo:");
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine("O arquivo não foi encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao importar o arquivo: " + ex.Message);
            }
        }
    }
}
